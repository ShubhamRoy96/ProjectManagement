import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { JwtService } from '../services/jwt.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private jwtService: JwtService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    const token: string = this.jwtService.getToken();
    if(token)
    {      
      var req = request.clone(
        {
          headers: request.headers.set("Authorization", "Bearer " + token)
        }
      );
      return next.handle(req);
    }
    return next.handle(request);
  }
}
