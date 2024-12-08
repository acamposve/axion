import { Component } from '@angular/core';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-recuperar-contrasena-modal',
  templateUrl: './recuperar-contrasena-modal.component.html',
  styleUrls: ['./recuperar-contrasena-modal.component.scss'],
})
export class RecuperarContrasenaModalComponent {
  name: string = '';

  constructor(private modalController: ModalController) {}

  cancel() {
    return this.modalController.dismiss(null, 'cancel');
  }

  confirm() {
    return this.modalController.dismiss(this.name, 'confirm');
  }
}