import { MakeService } from "./../../Services/make.service";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-vehicle-form",
  templateUrl: "./vehicle-form.component.html",
  styleUrls: ["./vehicle-form.component.css"]
})
export class VehicleFormComponent implements OnInit {
  makes;
  constructor(private makeservice: MakeService) {}

  ngOnInit() {
    this.makeservice.getMakes().subscribe(response => {
      this.makes = response;
      console.log(this.makes);
    });
  }
}
