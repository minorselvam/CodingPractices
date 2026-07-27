import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TopSectionComponent } from './layout/top-section/top-section.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TopSectionComponent],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {}
