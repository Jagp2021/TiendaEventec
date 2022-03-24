import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { ProductosComponent } from './Components/productos/productos.component';
import { ResumenComponent } from './Components/resumen/resumen.component';
import { ListadoComponent } from './Components/listado/listado.component';
import { ConfirmacionComponent } from './components/confirmacion/confirmacion.component';
import { MaterialModule } from './material.module';
import { PaymentService } from './services/payment.service';
import { OrdenService } from './services/orden.service';
import { AuthService } from './services/auth.service';
import { ProductoService } from './services/producto.service';
import { AppRoutingModule } from './app.routes';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';

const services = [PaymentService,OrdenService,AuthService,ProductoService];
@NgModule({
  declarations: [          
            AppComponent,
            ProductosComponent,
            ResumenComponent,
            ListadoComponent,
            ConfirmacionComponent,
            LoginComponent,           
      ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    MaterialModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule
  ],
  providers: [services],
  bootstrap: [AppComponent]
})
export class AppModule { }
