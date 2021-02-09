import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-sign-bottons',
  templateUrl: './sign-bottons.component.html',
  styleUrls: ['./sign-bottons.component.scss']
})
export class SignBottonsComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  toLog() {
    this.router.navigate(['login']);
  }

  toReg() {
    this.router.navigate(['register']);
  }
}
