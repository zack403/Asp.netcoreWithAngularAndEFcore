import { VehicleService } from "./../../Services/vehicle.service";
import { Component, OnInit, AnimationKeyframe } from "@angular/core";

@Component({
  selector: "app-vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"]
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models: any[];
  vehicle: any = {
    features: [],
    contact: {}
  };
  features;

  constructor(private vehicleservice: VehicleService) {}

  ngOnInit() {
    this.vehicleservice.getMakes().subscribe(response => {
      this.makes = response;
      console.log(this.makes);
    });

    this.vehicleservice.getFeatures().subscribe(response => {
      this.features = response;
    });
  }

  onMakeChange() {
    // tslint:disable-next-line:triple-equals
    const selectedmake = this.makes.find(m => m.id == this.vehicle.makeId);
    this.models = selectedmake ? selectedmake.models : [];
    delete this.vehicle.modelId;
  }

  onfeaturetoggle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId);
    } else {
      const index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1);
    }
  }

  submit() {
    this.vehicleservice
      .create(this.vehicle)
      .subscribe(response => console.log(response), err => {});
  }
}
