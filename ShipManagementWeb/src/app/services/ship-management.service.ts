import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ship } from '../models/ship.model';
import { API_CONFIG } from './api.config';
import { HttpBaseService } from './http-base.service';

@Injectable({
  providedIn: 'root'
})
export class ShipManagementService extends HttpBaseService{

  constructor(public _http: HttpClient) {
    super(_http);
  }

  public GetShips() :Observable<Ship[]>{
    return this.query<Ship>(API_CONFIG.API_SHIPS);
  }

  public AddShip(ship:Ship) :Observable<Ship>{
    return this.post<Ship>(API_CONFIG.API_SHIPS,{'shipDto':ship});
  }

  public UpdateShip(ship:any) : Observable<Ship>{

    return this.put(API_CONFIG.API_SHIPS,{'shipDto':ship});
  }

  public DeleteShip(id:number):Observable<number>{
    return this.delete(API_CONFIG.API_SHIPS, id);
  }
}
