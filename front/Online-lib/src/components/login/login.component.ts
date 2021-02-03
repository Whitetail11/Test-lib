import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/models/Login';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }

  error: string;
  form: FormGroup;
  
  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required])
      });
  }
  
  login() {
    this.error = null;
    const login: Login = this.form.value;

    this.authService.login(login).subscribe((value) => {
      console.log('value');
      this.router.navigate(['books']);
    }, error => {
      console.log(error)
      this.error = error.error[0];
    });
  }
}
