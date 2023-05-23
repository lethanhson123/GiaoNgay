import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderDeliveryPaymentHistoryService } from 'src/app/shared/OrderDeliveryPaymentHistory.service';

@Component({
  selector: 'app-order-delivery-payment-history-detail',
  templateUrl: './order-delivery-payment-history-detail.component.html',
  styleUrls: ['./order-delivery-payment-history-detail.component.css']
})
export class OrderDeliveryPaymentHistoryDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public OrderDeliveryPaymentHistoryService: OrderDeliveryPaymentHistoryService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<OrderDeliveryPaymentHistoryDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }
  ngOnInit(): void {
  }
  onClose() {
    this.dialogRef.close();
  }
  onSubmit(form: NgForm) {
    this.OrderDeliveryPaymentHistoryService.SaveAsync(form.value).subscribe(
      res => {
        this.notificationService.success(environment.SaveSuccess);
        this.onClose();
      },
      err => {
        this.notificationService.warn(environment.SaveNotSuccess);
        this.onClose();
      }
    );
  }
}
