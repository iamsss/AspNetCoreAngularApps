import { VehicleService } from './../services/vehicle.service';
import { Component, OnInit, NgZone } from '@angular/core';
import { ToastyService } from 'ng2-toasty';
import { ActivatedRoute, Router, Route } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';

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
    var sources = [
      this.vehicleService.getMakes(),
      this.vehicleService.getFeatures(),
    ];
    if (this.vehicle.id)
      sources.push(this.vehicleService.getVehicle(this.vehicle.id));

    Observable.forkJoin(sources).subscribe(data => {
      this.makes = data[0];
      this.features = data[1];
      if (this.vehicle.id)
        this.vehicle = data[2];
    }, err => {
      if (err.status == 404)
        this.router.navigate(['/home']);
    });
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
