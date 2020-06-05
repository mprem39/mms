import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MemberService } from './member.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';
import { Member } from '../models/Member';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {
  @Output() cancelMember = new EventEmitter();
  member: Member;
  memberForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private fb: FormBuilder, private memberService: MemberService,
              private router: Router , private toastr: ToastrService) { }

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red'
    };
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.memberForm = this.fb.group(
      {
        id: ['', Validators.required],
        name: ['', Validators.required],
        teamLeadId: ['', Validators.required],
        teamLeadName: ['', Validators.required],
        doj: [null, Validators.required],
        address: ['', Validators.required],
      }
    );
  }

  AddMember() {
    if (this.memberForm.valid) {
      this.member = Object.assign({}, this.memberForm.value);
      this.memberService.addMember(this.member).subscribe(
        () => {
          this.toastr.success('Member added successfully!');
        },
        error => {
          this.toastr.error(error);
        },
        () => {

            this.router.navigate(['/memberlist']);

        }
      );
    }
  }

  cancel() {
    this.cancelMember.emit(false);
  }
}
