import { MakeService } from './../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vechile-form',
  templateUrl: './vechile-form.component.html',
  styleUrls: ['./vechile-form.component.css']
})
export class VechileFormComponent implements OnInit {

  makes: any;
  vehicle = {
    make: []
  };
  models: any[];
  constructor(private makeService: MakeService) { }

 

  ngOnInit() {
        this.makeService.getMakes().subscribe(makes => {
          this.makes = makes;
          console.log("MAKES", this.makes);
        });
       }
   onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
       }
}
