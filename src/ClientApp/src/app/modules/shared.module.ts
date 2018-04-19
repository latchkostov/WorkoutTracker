import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatButtonModule, MatFormFieldModule, MatDialogModule, MatInputModule } from '@angular/material';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { MultiSelectModule } from 'primeng/multiselect';
import { RadioButtonModule } from 'primeng/radiobutton';
import { GrowlModule } from 'primeng/growl';
import { MessageService } from 'primeng/components/common/messageservice';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    GrowlModule,
    MatButtonModule,
    HttpClientModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule ,
    NgbModule.forRoot(),
    MultiSelectModule,
    RadioButtonModule
  ],
  declarations: [],
  exports: [
    CommonModule,
    FormsModule,
    GrowlModule,
    HttpClientModule,
    MatButtonModule,
    MatFormFieldModule,
    MatDialogModule,
    MatInputModule ,
    NgbModule,
    MultiSelectModule,
    RadioButtonModule
  ],
  providers: [
    MessageService
  ]
})
export class SharedModule { }
