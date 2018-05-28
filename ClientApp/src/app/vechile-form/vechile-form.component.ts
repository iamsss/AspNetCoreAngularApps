import { MakeService } from './../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vechile-form',
  templateUrl: './vechile-form.component.html',
  styleUrls: ['./vechile-form.component.css']
})
export class VechileFormComponent implements OnInit {

  makes;
  constructor(private makeService: MakeService) { }

 

  ngOnInit() {
        this.makeService.getMakes().subscribe(makes => {
          this.makes = makes;
          console.log("MAKES", this.makes);
        });
       }
}
