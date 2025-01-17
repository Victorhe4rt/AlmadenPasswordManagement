import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalAddComponentComponent } from './modal-add-component.component';

describe('ModalAddComponentComponent', () => {
  let component: ModalAddComponentComponent;
  let fixture: ComponentFixture<ModalAddComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalAddComponentComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalAddComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
