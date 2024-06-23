import { Component } from '@angular/core';
import { MazeApiService } from '../maze-api.service'

@Component({
  selector: 'app-maze-trajectory',
  templateUrl: './maze-trajectory.component.html',
  styleUrl: './maze-trajectory.component.css'
})
export class MazeTrajectoryComponent {
  inputText : string = '';
  result: any;

  constructor(private mazeService: MazeApiService) {

  }
  GetLaserTrajectory() {
      const inputArray = this.inputText.split('\n');
      this.mazeService.GetLaserTrajectory(inputArray).subscribe(a => {
        this.result = a;
      });
  }
}
