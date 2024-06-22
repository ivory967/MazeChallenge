import { TestBed } from '@angular/core/testing';

import { MazeApiService } from './maze-api.service';

describe('MazeApiService', () => {
  let service: MazeApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MazeApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
