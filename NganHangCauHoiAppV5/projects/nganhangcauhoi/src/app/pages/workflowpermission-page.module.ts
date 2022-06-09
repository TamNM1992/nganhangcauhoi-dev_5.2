import { NgModule } from '@angular/core';
import { TnxSharedModule } from 'tnx-shared';
import { WorkflowPermissionWithRouteModule } from 'tnx-nganhangcauhoi-service/workflowpermission';

@NgModule({
    imports: [
        TnxSharedModule,
        WorkflowPermissionWithRouteModule
    ]
})
export class WorkflowPermissionPageModule { }
       
