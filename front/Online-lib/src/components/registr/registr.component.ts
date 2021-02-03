import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-registr',
  templateUrl: './registr.component.html',
  styleUrls: ['./registr.component.scss']
})
export class RegistrComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }
  
  error: string;
  form: FormGroup;

  ngOnInit(): void {
    this.form = new FormGroup ({
      name: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required])
    });
  }

  register() {
    this.error = null;
    const registr = this.form.value;

    this.authService.register(registr).subscribe(() => {
      this.router.navigate(['books']);
    }, error => {
      console.log(error)
      this.error = error.error[0];
    })
  }

  getEmailErrorMessage() {
    if (this.form.get('email').hasError('required'))
    {
      return 'Email is required';
    }
    return 'Email is invalid';
  }

  toLog() {
    this.router.navigate(['login']);
  }
}