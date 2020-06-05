import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Member } from '../models/Member';
import { Point } from '../models/Point';
import { MemberParams } from '../models/MemberParams';
import { PointoToReturn } from '../models/PointoToReturn';
import { ptBrLocale } from 'ngx-bootstrap/chronos/i18n/pt-br';
import { Observable ,  of} from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  baseUrl = environment.apiUrl + 'Member/';
  constructor(private http: HttpClient) { }
  addMember(member: Member) {
    return this.http.post(this.baseUrl + 'addmember', member);
  }
  getMembers(){
    return this.http.get(this.baseUrl + 'getallmembers');
  }
  addPoint(point: Point) {
    return this.http.post(this.baseUrl + 'addpoint', point);
  }

  getPoints( memberParams?: MemberParams ): Observable<PointoToReturn>{
    let params = new HttpParams();
    if (memberParams != null) {
      params = params.append('memberId', memberParams.memberId.toString());
      params = params.append('teamLeadId', memberParams.teamLeadId.toString());

    }
    return this.http.get(this.baseUrl + 'getpointdetails', { observe: 'response', params })
    .pipe(
      map(response => {
        return response.body as PointoToReturn;
      })
    );

  }
}
