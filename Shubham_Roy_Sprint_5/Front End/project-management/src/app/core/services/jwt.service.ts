import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  readonly token = 'JWTToken';

  constructor() { }

  saveToken(jwtToken: string){
    	window.localStorage[this.token] = jwtToken;
  }

  getToken(): string{
    return window.localStorage[this.token];
  }

  purgeToken(){
    window.localStorage.removeItem(this.token);
  }

}
