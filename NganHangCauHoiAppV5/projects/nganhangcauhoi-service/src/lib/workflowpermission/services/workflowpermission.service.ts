

import { HttpClient } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { BaseService, ModuleConfigService, ResponseResult } from 'tnx-shared';
@Injectable({
    providedIn: 'root'
})
export class WorkflowPermissionService extends BaseService {
    entityName = 'WorkflowPermission';
    serviceCode = 'nganhangcauhoi';

    constructor(http: HttpClient, injector: Injector,
        private _moduleConfigService: ModuleConfigService) {
        super(http, injector, `${_moduleConfigService.getConfig().environment.apiDomain.nganhangcauhoiEndpoint}/${_moduleConfigService.getConfig().environment.apiVersion}/WorkflowPermission`);
        this.endPoint = _moduleConfigService.getConfig().environment.apiDomain.nganhangcauhoiEndpoint;
    }
}