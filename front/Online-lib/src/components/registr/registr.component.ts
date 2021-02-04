import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registr',
  templateUrl: './registr.component.html',
  styleUrls: ['./registr.component.scss']
})
export class RegistrComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router, private toastr: ToastrService) { }
  
  error: string;
  form: FormGroup;

  ngOnInit(): void {
    this.form = new FormGroup ({
      name: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{6,}')])
    });
  }

  register() {
    this.error = null;
    const registr = this.form.value;

    this.authService.register(registr).subscribe(() => {
      this.router.navigate(['']);
    }, error => {
      this.error = error.error[0];
      this.toastr.error(this.error);
    })
  }
  toLog() {
    this.router.navigate(['login']);
  }
}