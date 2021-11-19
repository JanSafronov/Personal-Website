class Block extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        return (
            <div id={"pres_block_" + this.props.ID} className="pres_block" style={{ "width": this.props.width, "height": this.props.height }}>
                <div id={"pres_src_" + this.props.ID} className="pres_src" style={{ "background": this.props.background }}>
                    <img src={this.props.img} width="25" />
                    
                </div>
                <div id={"pres_content_" + this.props.ID} className="pres_content">
                </div>
            </div>
        );
    }
}

class PresBlock extends React.Component {
    constructor(props) {
        super(props);

    }

    render() {
        let resources = this.props.source;
        return (
            <div id={"pres_block_" + this.props.ID} className="pres_block" style={{"width": this.props.width, "height": this.props.height}}>
                <div id={"pres_src_" + this.props.ID} className="pres_src" style={{ "background": this.props.background }}>
                    <SVGElement />
                    
                </div>
                <div id={"pres_content_" + this.props.ID} className="pres_content">
                    {
                        function () {
                            let r = []
                            for (let i = 0; i < resources.length; i++) {
                                r.push(<a href={resources[i]}>{resources[i]}</a>);
                                r.push(<hr />);
                            }
                            return r;
                        }()
                    }
                </div>
            </div>
        );
    }
}

class SVGElement extends React.Component {
    constructor(props) {
        super(props);

        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        window.open("https://github.com/Pomid0rchik", "_blank");
    }

    render() {
        return (
            <svg id="temp_svg" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" onClick={this.handleClick}>
                <path d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z"/>
            </svg>
        );
    }
}

function openSelection() {
    $("#item-select").toggle();
}

function closeSelection() {
    $("#item-select").css("display", "none");
}

/*document.addEventListener("click", (e) => {
    let target = document.getElementById(e.target.id);
    let op = $("#nav-item-o > *").get();
    op.push(...$("#item-select > *").get());

    if (op.findIndex(t => t == target) == -1) {
        $("#item-select").css("display", "none");
    }
});*/

function Startup() {
    var req = $.ajax("");

    req.done(function () {
        let l = [{
            title: "Websites",
            background: "rgba(168, 168, 168, 0.8)",
            width: "220px",
            height: "240px"
        },
        {
            title: "AuthoBson",
            img: "media/icon.png",
            background: "rgb(111, 202, 117)",
            width: "280px",
            height: "240px"
        }];
        let r = [];
        let resources = req.getResponseHeader("Resources").split(", ");

        for (let i = 0; i < 1; i++) {
            r.push(<PresBlock ID={i} title={l[i].title} source={resources} background={l[i].background} width={l[i].width} height={l[i].height} />);
        }
        r.push(<Block ID={1} title={l[1].title} img={l[1].img} background={l[1].background} width={l[1].width} height={l[1].height} />)

        ReactDOM.render(r, document.getElementById("items-container"));
    });
}

Startup();