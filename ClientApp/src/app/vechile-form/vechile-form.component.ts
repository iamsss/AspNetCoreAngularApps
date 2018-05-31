import { VehicleService } from './../services/vehicle.service';
import { Component, OnInit, NgZone } from '@angular/core';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router, Route } from '@angular/router';

@Component({
  selector: 'app-vechile-form',
  templateUrl: './vechile-form.component.html',
  styleUrls: ['./vechile-form.component.css']
})
export class VechileFormComponent implements OnInit {

  makes: any;
  vehicle: any = {
    id: null,
    makeId: '',
    modelId: '',
    features: [],
    contact: {}
  };
  models: any[];
  features: any;
  constructor(
    private route: ActivatedRoute,
    private router: Router, private vehicleService: VehicleService,
    private toastyService: ToastyService,
    private ngZone: NgZone) {
    route.params.subscribe(p => {
      this.vehicle.id = +p['id'];
    });
  }



  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicle.id)
      .subscribe(v => {
        this.vehicle = v;
      }, err => {
        if (err.status == 404)
          this.router.navigate(['/home']);
      });
    this.vehicleService.getMakes().subscribe(makes => {
      this.makes = makes;
      console.log("MAKES", this.makes);
    });
    this.vehicleService.getFeatures().subscribe(features =>
      this.features = features);
  }
  onMakeChange() {
    var selectedMake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    delete this.vehicle.modelId;
  }
  onFeatureToggle(featureId, $event) {
    if ($event.target.checked)
      this.vehicle.features.push(featureId);
    else {
      var index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicleService.create(this.vehicle)
      .subscribe(x => {
        this.toastyService.success({
          title: "Toast It!",
          msg: "Data Sent Sucessfully",
          showClose: true,
          timeout: 5000,
          theme: "material"
        });
      }, err => {
        console.log("Error");
        this.ngZone.run(() => {
          this.toastyService.error({
            title: "Toast It!",
            msg: "Some Error",
            showClose: true,
            timeout: 5000,
            theme: "material"
          });
        });

      }
      );
  }


}
