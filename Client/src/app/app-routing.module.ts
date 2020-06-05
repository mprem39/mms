import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberComponent } from './member/member.component';
import { MemberListComponent } from './member/member-list/member-list.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'addmember', component: MemberComponent},
  { path: 'memberlist', component: MemberListComponent},
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
