import { Component } from '@angular/core';
import { SidebarComponent } from "../sidebar/sidebar.component";

@Component({
    selector: 'app-atas-page',
    standalone: true,
    templateUrl: './atas-page.component.html',
    styleUrl: './atas-page.component.css',
    imports: [SidebarComponent]
})
export class AtasPageComponent {

}
