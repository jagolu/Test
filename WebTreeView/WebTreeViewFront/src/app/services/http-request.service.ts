import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpRequestService {

  private _baseUrl: string = "https://localhost:7202/"

  constructor(private _http:HttpClient) { }

  private getRequest<T>(path:string){
    let options = 
    {
      headers:this.basicHeaders()
    };
    return this._http.get<T>(this._baseUrl+path, options);
  }

  private basicHeaders(){
    return new HttpHeaders({
      "Access-Control-Allow-Origin": "*",
      "Accept": "application/json",
      "Content-Type": "application/json"
    });
  }

  public getFileJsonRetriever<T>(fileName:string){
    return this.getRequest<T>("jsonretriever?jsonFileName="+fileName);
  }
}
