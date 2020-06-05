import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MemberComponent } from './member.component';
import { MemberListComponent } from './member-list/member-list.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import {ToastrModule } from 'ngx-toastr';
import { ManagePointsComponent } from './manage-points/manage-points.component';
import { ViewPointsComponent } from './view-points/view-points.component';
import { ModalModule } from 'ngx-bootstrap/modal';


@NgModule({
  declarations: [MemberComponent, MemberListComponent, ManagePointsComponent, ViewPointsComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    ModalModule.forRoot()
  ]
})
export class MemberModule { }
