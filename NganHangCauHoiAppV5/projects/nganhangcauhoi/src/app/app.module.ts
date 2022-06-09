

import { NgModule } from '@angular/core';
import { CommonAppComponentComponent, PublicFunction, TnxSharedModule } from 'tnx-shared';
import { SignalRModule } from 'ng2-signalr';
import { environment } from '../environments/environment';
import { AppRoutes } from './app.routing';
import { AppComponent } from './app.component';

export function getTnComponentConfigProvider() {
    return { environment, appCode: 'NGANHANGCAUHOI' };
}

export function getImport() {
    return PublicFunction.importRootModule(environment);
}

export function getSignalrConfig() {
    return PublicFunction.getSignalrConfig(environment);
}

PublicFunction.registerLocaleData();

@NgModule({
    imports: [
        ...getImport(),
        TnxSharedModule.forRoot(getTnComponentConfigProvider),
        SignalRModule.forRoot(getSignalrConfig),
        AppRoutes,
    ],
    providers: PublicFunction.useRootProvider(environment),
    bootstrap: [AppComponent],
    declarations: [AppComponent]
})
export class AppModule { }
