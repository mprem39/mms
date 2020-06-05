import { Component, OnInit } from '@angular/core';
import { Member } from 'src/app/models/Member';
import { MemberService } from '../member.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ManagePointsComponent } from '../manage-points/manage-points.component';
import { ViewPointsComponent } from '../view-points/view-points.component';
import { MemberParams } from 'src/app/models/MemberParams';
import { PointoToReturn } from 'src/app/models/PointoToReturn';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {
  members: Member[];
  bsModalRef: BsModalRef;
  params: MemberParams = new MemberParams();
  pointsToReturn: PointoToReturn = new PointoToReturn();
  constructor(private memberService: MemberService, private toastr: ToastrService,
              private modalService: BsModalService) { }

  ngOnInit() {
    this.getUsersWithRoles();
  }
  getUsersWithRoles() {
    this.memberService.getMembers().subscribe((members: Member[]) => {
      this.members = members;
    }, error => {
    this.toastr.error(error);
    });
  }

  mangePointsModal(member: Member){
    const initialState = {
      member
     };
    this.bsModalRef = this.modalService.show(ManagePointsComponent, {initialState});
  }

  viewPointsModal(member: Member){
    this.params.memberId = member.id;
    this.params.teamLeadId = member.teamLeadId;
    this.memberService.getPoints(this.params).subscribe((pointsToReturn: PointoToReturn) => {
      const initialState = {pointsToReturn};
      this.bsModalRef = this.modalService.show(ViewPointsComponent, {initialState});
    }, error => {
      this.toastr.error(error);
      });
    }
}
