// interceptar chamadas HTTP para inserir automaticamente o Authorization
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/internal/operators/tap';

@Injectable({providedIn: 'root'})
export class AuthInterceptor implements HttpInterceptor {

    constructor(private router: Router) {}

    // tslint:disable-next-line: max-line-length
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {       // recebe a requisição e um manipulador de requisições
        if (localStorage.getItem('token') !== null) {
            // tslint:disable-next-line: max-line-length
            const cloneReq = req.clone({                                                    // clona a requisição para inserir o header de autorização
                headers: req.headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`)  // insere o header na url
            });
            return next.handle(cloneReq).pipe(              // retorna um observable com a url + header de autorização
            tap(                                            // tratar os possíveis erros
                    succ => {},                             // em caso de sucesso não retorna nada
                    error => {
                        if (error.status === 401) {         // se não autorizar 401
                            this.router.navigateByUrl('user/login');        // redireciona para login
                        }
                    }
                )
            );
        } else {
    return next.handle(req.clone());                        // caso não haja toeken apenas retorna a requisição que foi passada
        }
    }
}