import { Component, OnInit, Inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NotificationService } from 'src/app/shared/notification.service';
import { OrderDeliveryHistoryService } from 'src/app/shared/OrderDeliveryHistory.service';
import { Membership } from 'src/app/shared/Membership.model';
import { MembershipService } from 'src/app/shared/Membership.service';

@Component({
  selector: 'app-order-delivery-history-detail',
  templateUrl: './order-delivery-history-detail.component.html',
  styleUrls: ['./order-delivery-history-detail.component.css']
})
export class OrderDeliveryHistoryDetailComponent implements OnInit {

  ID: number = environment.InitializationNumber;
  constructor(
    public OrderDeliveryHistoryService: OrderDeliveryHistoryService,
    public MembershipService: MembershipService,
    public notificationService: NotificationService,
    public dialogRef: MatDialogRef<OrderDeliveryHistoryDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.ID = data["ID"] as number;
  }
  ngOnInit(): void {
    this.getShipperToList();
  }
  onClose() {
    this.dialogRef.close();
  }
  onChangeDateCreated(value) {
    this.OrderDeliveryHistoryService.formData.DateCreated = new Date(value);
  }
  getShipperToList() {
    this.MembershipService.GetByParentIDToListAsync(environment.ShipperID).subscribe(
      res => {
        this.MembershipService.listShipper = (res as Membership[]).sort((a, b) => (a.Display > b.Display ? 1 : -1));
        if (this.MembershipService.listShipper) {
          if (this.MembershipService.listShipper.length > 0) {
            if (this.OrderDeliveryHistoryService.formData.ID == 0) {
              this.OrderDeliveryHistoryService.formData.ShipperID = this.MembershipService.listShipper[0].ID;              
            }
          }
        }
      },
      err => {
      }
    );
  }
  onSubmit(form: NgForm) {
    this.OrderDeliveryHistoryService.SaveAsync(form.value).subscribe(
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
