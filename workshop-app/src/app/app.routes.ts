import { Routes } from '@angular/router';
import {AtasPageComponent} from './atas-page/atas-page.component'
import { DashboardsPageComponent } from './dashboards-page/dashboards-page.component';
export const routes: Routes = [
    {path: 'atas', component: AtasPageComponent},
    {path: 'dashboards', component: DashboardsPageComponent}
];
