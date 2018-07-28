import { MakeService } from "./../../Services/make.service";
import { Component, OnInit, AnimationKeyframe } from "@angular/core";

@Component({
  selector: "app-vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"]
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models: any[];
  vehicle: any = {};
  constructor(private makeservice: MakeService) {}

  ngOnInit() {
    this.makeservice.getMakes().subscribe(response => {
      this.makes = response;
      console.log(this.makes);
    });
  }

  onMakeChange() {
    // tslint:disable-next-line:triple-equals
    const selectedmake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedmake ? selectedmake.models : [];
  }
}
