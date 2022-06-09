import { NgModule } from '@angular/core';
import { TnxSharedModule } from 'tnx-shared';
import { WorkflowPermissionFormComponent } from './workflowpermission-form/workflowpermission-form.component';
import { WorkflowPermissionComponent } from './workflowpermission.component';
import { WorkflowPermissionRoutes } from './workflowpermission.routing';

export function declaration() {
    return [WorkflowPermissionComponent, WorkflowPermissionFormComponent];
}

@NgModule({
    imports: [
        TnxSharedModule
    ],
    declarations: declaration(),
    exports: declaration()
})
export class WorkflowPermissionModule {
}

@NgModule({
    imports: [WorkflowPermissionModule, WorkflowPermissionRoutes],
    exports: [WorkflowPermissionModule]
})
export class WorkflowPermissionWithRouteModule {
}
