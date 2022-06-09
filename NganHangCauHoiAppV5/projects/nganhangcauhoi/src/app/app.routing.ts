import { ModuleWithProviders } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SplashComponentComponent } from 'tnx-shared';

const routes: Routes = [
    {
        path: '',
        component: SplashComponentComponent,
    },
    {
		path: 'workflowpermission',
		loadChildren: () => import ('./pages/workflowpermission-page.module').then(m => m.WorkflowPermissionPageModule),
	},
	
];
export const AppRoutes = RouterModule.forRoot(routes);
