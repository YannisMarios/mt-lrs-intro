import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { User } from '../user.model';

interface DialogData {
  user: User;
}

@Component({
  selector: 'app-dialog',
  templateUrl: './user-delete-modal.component.html',
  styleUrls: ['./user-delete-modal.component.css'],
})
export class DeleteUserModalComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<DeleteUserModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(): void {}
}
