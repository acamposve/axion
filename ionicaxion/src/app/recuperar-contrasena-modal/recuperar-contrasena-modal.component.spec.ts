import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { RecuperarContrasenaModalComponent } from './recuperar-contrasena-modal.component';

describe('RecuperarContrasenaModalComponent', () => {
  let component: RecuperarContrasenaModalComponent;
  let fixture: ComponentFixture<RecuperarContrasenaModalComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ RecuperarContrasenaModalComponent ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(RecuperarContrasenaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
