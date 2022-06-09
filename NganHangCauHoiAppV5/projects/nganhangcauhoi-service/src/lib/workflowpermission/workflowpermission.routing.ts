import { Routes, RouterModule } from '@angular/router';
import { WorkflowPermissionComponent } from './workflowpermission.component';

const routes: Routes = [
    {
        path: '',
        component: WorkflowPermissionComponent
    },
];

export const WorkflowPermissionRoutes = RouterModule.forChild(routes);
