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
  //file selected will convert the file to the list of strings (inputText)
  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;

    if (input.files) {
      const file = input.files[0];

      if (file) {
        const reader = new FileReader();
        reader.onload = () => {
          this.inputText = reader.result as string;
        };
        reader.readAsText(file);
      }
    }
  }
  //service call, some weirness happened here where some empty characters are read from the text file, thats why the replace occurs below
  GetLaserTrajectory() {
    const inputArray = this.inputText.replace(/\r/g, '').split('\n')
      this.mazeService.GetLaserTrajectory(inputArray).subscribe(a => {
        this.result = a;
      });
  }
}
