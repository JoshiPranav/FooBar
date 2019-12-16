import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {

  private errorMessage: string;
  constructor(private activatedroute: ActivatedRoute) { }

  ngOnInit() {
    this.errorMessage = this.activatedroute.snapshot.paramMap.get('errorMessage');
  }

}
