import { ClientesComponent } from './Pages/clientes/clientes.component';
import { OportunidadesComponent } from './Pages/oportunidades/oportunidades.component';
import { GerenciaUserComponent } from './Pages/gerencia-user/gerencia-user.component';
import { ErrorComponent } from './Pages/error/error.component';
import { LoginBlockService } from './Services/guard/login-block.service';
import { GuardService } from './Services/guard/guard.service';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { LoginComponent } from './Pages/login/login.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ResetsenhaComponent } from './Pages/Resetsenha/resetsenha.component';

const routes: Routes = [
  { path: '', component: LoginComponent, canActivate: [LoginBlockService] },
  { path: 'resetSenha', component: ResetsenhaComponent},

  { path: 'DashBoard', component: DashboardComponent, canActivate: [GuardService] },
  { path: 'Users', component: GerenciaUserComponent, canActivate: [GuardService] },
  { path: 'Oportunidades', component: OportunidadesComponent, canActivate: [GuardService] },
  { path: 'Clientes', component: ClientesComponent, canActivate: [GuardService] },

  { path: '**', component: ErrorComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
