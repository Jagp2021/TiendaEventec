import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmacionComponent } from './components/confirmacion/confirmacion.component';
import { ListadoComponent } from './Components/listado/listado.component';
import { ProductosComponent } from './Components/productos/productos.component';
import { ResumenComponent } from './Components/resumen/resumen.component';

const appRoutes: Routes = [
    { path: 'listado', component: ListadoComponent},
    { path: 'productos', component: ProductosComponent},
    { path: 'resumen', component: ResumenComponent},
    { path: 'confirmacion/:id', component: ConfirmacionComponent},
    { path: '', redirectTo: 'productos', pathMatch: 'full' }
  ];

  @NgModule({
    imports: [
      RouterModule.forRoot(appRoutes, { useHash: true }),
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }