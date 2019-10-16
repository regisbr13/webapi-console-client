/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ComputerService } from './Computer.service';

describe('Service: Computer', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ComputerService]
    });
  });

  it('should ...', inject([ComputerService], (service: ComputerService) => {
    expect(service).toBeTruthy();
  }));
});
