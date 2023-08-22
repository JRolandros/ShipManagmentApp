import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ShipListComponent } from './ship-list/ship-list.component';
import { authGuard } from './auth.guard';

const routes: Routes = [
  { path:'',component: ShipListComponent,canActivate:[authGuard]},
  { path: 'login', component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
