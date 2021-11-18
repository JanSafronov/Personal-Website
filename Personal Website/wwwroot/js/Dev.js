
class Repository extends React.Component {
    constructor(props) {
        super(props);

        this.statusChange = this.statusChange.bind(this);
    }

    componentDidMount() {
        this.statusChange();
    }

    statusChange() {
        let res;
        switch (this.props.status) {
            case "In process":
                res = "red";
                break;
            case "Not deployed":
                res = "#f5f500";
                break;
            case "Deployed":
                res = "green";
        };

        $("#status-" + this.props.ID).css("color", res);
    }

    render() {
        return (
            <div id={"repos-" + this.props.ID} className="repos">
                <nav>
                    <p>Type: {this.props.type}</p>
                    <p>Status: <p id={"status-" + this.props.ID}>{this.props.status}</p></p>
                </nav>
                <div id={"repos-main-" + this.props.ID} className="repos-main">
                    <h4>{this.props.main}</h4>
                </div>
                <div id={"repos-fig-" + this.props.ID} className="repos-fig">
                    <div id={"fig-details-" + this.props.ID} className="fig-details">
                        <h6>GitHub: <a href={this.props.Href}>Repository</a></h6>
                    </div>
                </div>
            </div>
        );
    }
}

ReactDOM.render(function () {
    let l = [{
        title: "'ValueTB' Application",
        status: "In process",
        type: "Windows Application",
        main: "WPF desktop application equipped with table management and calculation of values and transformation of data and import of various table formats.",
        href: "https://github.com/Pomid0rchik/ValueTB-WPF-Application"
    }, {
        title: "'Online Dish' Website",
        status: "In process",
        type: "ASP.NET Website",
        main: "ASP.NET Full stack web project template of a food delivery company.",
        href: ""
    }, {
        title: "'DebunkInfo' Website",
        status: "Not deployed",
        type: "ASP.NET Framework Website",
        main: "ASP.NET Framework project full stack presentation repository of a fact checking and user interactive website.",
        href: "https://github.com/Pomid0rchik/DebunkInfo-WebSite-Presentation"
    }];
    let r = [];
    for (let i = 0; i < l.length; i++) {
        r.push(<Repository ID={i} title={l[i].title} status={l[i].status} type={l[i].type} main={l[i].main} Href={l[i].href}/>);
    }
    return r;
}(), document.getElementById("main-container"));
