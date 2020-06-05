import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Member } from 'src/app/models/Member';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { Point } from 'src/app/models/Point';
import { MemberService } from '../member.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-manage-points',
  templateUrl: './manage-points.component.html',
  styleUrls: ['./manage-points.component.css']
})
export class ManagePointsComponent implements OnInit {
 member: Member;
 point: Point = new Point() ;
 @ViewChild('point') pointInputRef: ElementRef;
 constructor(public bsModalRef: BsModalRef , private memberService: MemberService ,  private toastr: ToastrService) {}

  ngOnInit(): void {
  }

  savePoint(){
    this.point.memberId = this.member.id;
    this.point.teamLeadId = this.member.teamLeadId;
    this.point.point = this.pointInputRef.nativeElement.value;
    this.point.dop = new Date((new Date()).getTime() + 24 * 60 * 60 * 1000);
    this.memberService.addPoint(this.point).subscribe(
         () => {
        this.toastr.success('Points added successfully!');
      },
      error => {
        this.toastr.error(error);
      }
    );
    this.bsModalRef.hide();
  }


}
