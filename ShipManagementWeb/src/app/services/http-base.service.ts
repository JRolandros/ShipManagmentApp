import { HttpClient, HttpHeaders } from "@angular/common/http";
import { API_CONFIG } from "./api.config";
import { Observable } from "rxjs/internal/Observable";

export abstract class HttpBaseService {

  baseUrl: string = API_CONFIG.BASE_URL;

  constructor(protected _httpClient:HttpClient) { }

  protected query<T>(route:string):Observable<T[]>{

    let headers=new HttpHeaders({
      'content-type': 'application/json',
      'Access-Control-Allow-Origi':'*'
    });

    return this._httpClient
    .get<T[]>(this.baseUrl+route,{headers:headers});
  }

  protected getSingle<T>(route:string):Observable<T>{
    let headers=new HttpHeaders({'content-type': 'application/json'});

    return this._httpClient
    .get<T>(this.baseUrl+route,{headers:headers});
  }

  protected post<T>(route:string,data:any) : Observable<T>{

    let headers=new HttpHeaders({'content-type': 'application/json'});

    return this._httpClient
    .post<T>(this.baseUrl+route,data,{headers:headers});
  }


  protected put<T>(route:string,data:any) : Observable<T>{

    let headers=new HttpHeaders({'content-type': 'application/json'});

    return this._httpClient
    .put<T>(this.baseUrl+route,data,{headers:headers});
  }

  protected delete(route:string,data:any) : Observable<any>{

    let headers=new HttpHeaders({'content-type': 'application/json'});

    return this._httpClient
    .delete(this.baseUrl+route+'?Id='+data,{headers:headers});
  }

}
