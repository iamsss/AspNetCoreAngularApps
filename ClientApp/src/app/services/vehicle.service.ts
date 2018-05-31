import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';


@Injectable()
export class VehicleService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  constructor(private http: HttpClient) { }

  getMakes(){
    return this.http.get('/api/makes');
  }

  getFeatures(){
    return this.http.get('/api/features');
  }
  
  create(vehicle) {
        console.log('In Create Vehicle',vehicle);
        return this.http.post('/api/vehicles', vehicle,this.httpOptions );
      }

      getVehicle(id) {
          return this.http.get('/api/vehicles/'  + id);
        }
}
