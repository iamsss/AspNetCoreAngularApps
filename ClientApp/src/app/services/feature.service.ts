import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class FeatureService {

 
  constructor(private http: HttpClient) { }
  
    getFeatures(){
      return this.http.get('/api/features');
    }

}
