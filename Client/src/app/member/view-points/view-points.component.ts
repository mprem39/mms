import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { MemberService } from '../member.service';
import { PointoToReturn } from 'src/app/models/PointoToReturn';

@Component({
  selector: 'app-view-points',
  templateUrl: './view-points.component.html',
  styleUrls: ['./view-points.component.css']
})
export class ViewPointsComponent implements OnInit {
  pointsToReturn: PointoToReturn;
  constructor(public bsModalRef: BsModalRef , private memberService: MemberService ,  private toastr: ToastrService) {}


  ngOnInit(): void {
  }

}
