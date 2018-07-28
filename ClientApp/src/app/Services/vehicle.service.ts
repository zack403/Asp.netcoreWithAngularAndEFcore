import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import "rxjs/add/operator/map";

@Injectable()
export class VehicleService {
  constructor(private http: HttpClient) {}

  getMakes() {
    return this.http.get("/api/makes").map(res => res);
  }

  getFeatures() {
    return this.http.get("/api/feautures").map(response => response);
  }
}
