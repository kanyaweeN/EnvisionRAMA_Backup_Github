import { Injectable } from '@angular/core';

@Injectable()
export class UtilitiesService {
    constructor(
    ) { }

    public OpenPACS(accession: string) {
        let optionUrl = 'toolbar=no,scrollbars=no,resizable=no,fullscreen=yes';
        optionUrl += ',screenX=-1920'; // + window.screenX;
        optionUrl += ',screenY=-313'; // + window.screenY;
        optionUrl += ',left=-1920'; // + window.screenLeft;
        // const pacsUrl = 'http://ramapacs%5Cpeerreview:1234@synapse:80/explore.asp?path=/All%20Studies./AccessionNumber=';
        const pacsUrl = 'http://miracle99/envisionPACSDirectlyServe/default.aspx?accession_no=';
        window.open(pacsUrl + accession, 'OpenPACS', optionUrl);
    }
}
