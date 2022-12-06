import { GetUserInfo } from './../../../../shared/models/get-user-info.model';
import { SettingsService } from './../../settings.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-setting-container',
  templateUrl: './setting-container.component.html',
  styleUrls: ['./setting-container.component.scss']
})
export class SettingContainerComponent {
  userInfo!: GetUserInfo;

  constructor(private settingService: SettingsService) {
    this.settingService.userInfo().subscribe(user => {
      this.userInfo = user;
    })
  }
}
