import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { BuyerDTO } from '../services/models/payment/buyer';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: FormGroup;
  constructor(public dialogRef: MatDialogRef<any>,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  }

  async buildForm(): Promise<void> {
    this.form = this.fb.group({
      nombre: new FormControl('',[Validators.required]),
      email: new FormControl('',[Validators.required,Validators.email]),
      phone: new FormControl('',[Validators.required]),
    });
  }

  get formularioControls(): FormGroup['controls'] {
    return this.form.controls;
  }

  ingresar(): void {
    if(this.form.valid) {
      const usuario: BuyerDTO = { name: this.formularioControls.nombre.value, 
        email: this.formularioControls.email.value, 
        mobile: this.formularioControls.phone.value};
      sessionStorage.setItem('usuario',JSON.stringify(usuario));
      this.dialogRef.close();
    }
    
  }

}
