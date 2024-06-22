import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MazeTrajectoryComponent } from './maze-trajectory.component';

describe('MazeTrajectoryComponent', () => {
  let component: MazeTrajectoryComponent;
  let fixture: ComponentFixture<MazeTrajectoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MazeTrajectoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MazeTrajectoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
